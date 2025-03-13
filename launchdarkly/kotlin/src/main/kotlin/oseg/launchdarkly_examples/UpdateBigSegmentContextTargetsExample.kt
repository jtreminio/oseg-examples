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
class UpdateBigSegmentContextTargetsExample
{
    fun updateBigSegmentContextTargets()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val included = SegmentUserList(
            add = listOf (),
            remove = listOf (),
        )

        val excluded = SegmentUserList(
            add = listOf (),
            remove = listOf (),
        )

        val segmentUserState = SegmentUserState(
            included = included,
            excluded = excluded,
        )

        try
        {
            SegmentsApi().updateBigSegmentContextTargets(
                projectKey = null,
                environmentKey = null,
                segmentKey = null,
                segmentUserState = segmentUserState,
            )
        } catch (e: ClientException) {
            println("4xx response calling SegmentsApi#updateBigSegmentContextTargets")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SegmentsApi#updateBigSegmentContextTargets")
            e.printStackTrace()
        }
    }
}
