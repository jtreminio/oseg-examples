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
class PatchExpiringTargetsForSegmentExample
{
    fun patchExpiringTargetsForSegment()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val instructions1 = PatchSegmentExpiringTargetInstruction(
            kind = PatchSegmentExpiringTargetInstruction.Kind.updateExpiringTarget,
            contextKey = "user@email.com",
            contextKind = "user",
            targetType = PatchSegmentExpiringTargetInstruction.TargetType.included,
            value = 1587582000000,
            version = 0,
        )

        val instructions = arrayListOf<PatchSegmentExpiringTargetInstruction>(
            instructions1,
        )

        val patchSegmentExpiringTargetInputRep = PatchSegmentExpiringTargetInputRep(
            comment = "optional comment",
            instructions = instructions,
        )

        try
        {
            val response = SegmentsApi().patchExpiringTargetsForSegment(
                projectKey = null,
                environmentKey = null,
                segmentKey = null,
                patchSegmentExpiringTargetInputRep = patchSegmentExpiringTargetInputRep,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SegmentsApi#patchExpiringTargetsForSegment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SegmentsApi#patchExpiringTargetsForSegment")
            e.printStackTrace()
        }
    }
}
