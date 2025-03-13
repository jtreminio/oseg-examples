package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PatchExpiringUserTargetsForSegmentExample
{
    fun patchExpiringUserTargetsForSegment()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val instructions1 = PatchSegmentInstruction(
            kind = PatchSegmentInstruction.Kind.addExpireUserTargetDate,
            userKey = "sample-user-key",
            targetType = PatchSegmentInstruction.TargetType.included,
            value = 16534692,
            version = 0,
        )

        val instructions = arrayListOf<PatchSegmentInstruction>(
            instructions1,
        )

        val patchSegmentRequest = PatchSegmentRequest(
            comment = "optional comment",
            instructions = instructions,
        )

        try
        {
            val response = SegmentsApi().patchExpiringUserTargetsForSegment(
                projectKey = "the-project-key",
                environmentKey = "the-environment-key",
                segmentKey = "the-segment-key",
                patchSegmentRequest = patchSegmentRequest,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SegmentsApi#patchExpiringUserTargetsForSegment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SegmentsApi#patchExpiringUserTargetsForSegment")
            e.printStackTrace()
        }
    }
}
