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
class PostSegmentExample
{
    fun postSegment()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val segmentBody = SegmentBody(
            name = "Example segment",
            key = "segment-key-123abc",
            description = "Bundle our sample customers together",
            unbounded = false,
            unboundedContextKind = "device",
            tags = listOf (
                "testing",
            ),
        )

        try
        {
            val response = SegmentsApi().postSegment(
                projectKey = null,
                environmentKey = null,
                segmentBody = segmentBody,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling SegmentsApi#postSegment")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling SegmentsApi#postSegment")
            e.printStackTrace()
        }
    }
}
